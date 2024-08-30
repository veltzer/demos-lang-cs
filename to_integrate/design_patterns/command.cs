// Command pattern  

using System;
using System.Collections;

// "Command"

abstract class Command
{
  // Methods
  abstract public void Execute();
  abstract public void UnExecute();
}

// "ConcreteCommand"

class CalculatorCommand : Command
{
  // Fields
  char _operator;
  int operand;
  Calculator calculator;

  // Constructor
  public CalculatorCommand( Calculator calculator,
                        char _operator, int operand )
  {
    this.calculator = calculator;
    this._operator = _operator;
    this.operand = operand;
  }

  // Properties
  public char Operator
  {
    set{ _operator = value; }
  }

  public int Operand
  {
    set{ operand = value; }
  }

  // Methods
  override public void Execute()
  {
    calculator.Operation( _operator, operand );
  }
 
  override public void UnExecute()
  {
     calculator.Operation( Undo( _operator ), operand );
  }

  // Private helper function
  private char Undo( char _operator )
  {
    char undo = ' ';
    switch( _operator )
    {
      case '+': undo = '-'; break;
      case '-': undo = '+'; break;
      case '*': undo = '/'; break;
      case '/': undo = '*'; break;
    }
    return undo;
  }
}

// "Receiver"

class Calculator
{
  private int total = 0;
  public void Operation( char _operator, int operand )
  {
    switch( _operator )
    {
      case '+': total += operand; break;
      case '-': total -= operand; break;
      case '*': total *= operand; break;
      case '/': total /= operand; break;
    }
    Console.WriteLine( "Total = {0} (following {1} {2})",
                    total, _operator, operand );
  }
}

// "Invoker"

class User
{
  private Calculator calculator = new Calculator();
  private ArrayList commands = new ArrayList();
  private int current = 0;
  public void Redo( int levels )
  {
    Console.WriteLine( "---- Redo {0} levels ", levels );
    // Perform redo operations
    for( int i = 0; i < levels; i++ )
      if( current < commands.Count - 1 )
        ((Command)commands[ current++ ]).Execute();
  }

  public void Undo( int levels )
  {
    Console.WriteLine( "---- Undo {0} levels ", levels );
    // Perform undo operations
    for( int i = 0; i < levels; i++ )
      if( current > 0 )
        ((Command)commands[ --current ]).UnExecute();
  }

  public void Compute( char _operator, int operand )
  {
    // Create command operation and execute it
    Command command = new CalculatorCommand(
                calculator, _operator, operand );
    command.Execute();

    // Add command to undo list
    commands.Add( command );
    current++;
  }
}

/// <summary>
/// CommandApp test
/// </summary>
public class CommandApp
{
  public static void Main( string[] args )
  {
    // Create user and let her compute
    User user = new User();

    user.Compute( '+', 100 );
    user.Compute( '-', 50 );
    user.Compute( '*', 10 );
    user.Compute( '/', 2 );

    // Undo and then redo some commands
    user.Undo( 4 );
    user.Redo( 3 );
  }
}  
