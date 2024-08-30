// Memento pattern 

using System;

// "Originator"

class SalesProspect
{
  private string name;
  private string phone;
  private double budget;
  public string Name
  {
    get{ return name; }
    set{ name = value; }
  }
  public string Phone
  {
    get{ return phone; }
    set{ phone = value; }
  }
  public double Budget
  {
    get{ return budget; }
    set{ budget = value; }
  }
  public Memento SaveMemento()
  {
    return (new Memento( name, phone, budget ));
  }

  public void RestoreMemento( Memento memento )
  {
    this.name = memento.Name;
    this.phone = memento.Phone;
    this.budget = memento.Budget;
  }

  public void Show()
  {
    Console.WriteLine( "\nSales prospect ---- " );
    Console.WriteLine( "Name: {0}", this.name );
    Console.WriteLine( "Phone: {0}", this.phone );
    Console.WriteLine( "Budget: {0:C}", this.budget );
  }
}

// "Memento"

class Memento
{
  private string name;
  private string phone;
  private double budget;
  public Memento(string name,string phone,double budget)
  {
    this.name = name;
    this.phone = phone;
    this.budget = budget;
  }
  public string Name
  {
    get{ return name; }
    set{ name = value; }
  }
  public string Phone
  {
    get{ return phone; }
    set{ phone = value; }
  }
  public double Budget
  {
    get{ return budget; }
    set{ budget = value; }
  }
}


class ProspectMemory
{
  // Fields
  private Memento memento;

  // Properties
  public Memento Memento
  {
    set{ memento = value; }
    get{ return memento; }
  }
}

/// <summary>
/// MementoApp test
/// </summary>
public class MementoApp
{
  public static void Main( string[] args )
  {
    SalesProspect s = new SalesProspect();
    s.Name = "Noel van Halen";
    s.Phone = "(412) 256-0990";
    s.Budget = 25000.0;
    s.Show();

    ProspectMemory m = new ProspectMemory();
    m.Memento = s.SaveMemento();

    s.Name = "Leo Welch";
    s.Phone = "(310) 209-7111";
    s.Budget = 1000000.0;
    s.Show();

    s.RestoreMemento( m.Memento );
    s.Show();
  }
} 
