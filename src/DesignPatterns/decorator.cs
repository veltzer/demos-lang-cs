//decorator

using System;

interface Widget { void draw(); }             

class TextField : Widget {           
   private int width, height;
   public TextField( int w, int h ) {
      width  = w;
      height = h;
   }
   public void draw() {
      Console.WriteLine("TextField: " + width + ", " + height );
   }
}
                                     
abstract class Decorator : Widget {   
   private Widget wid;                
   public Decorator( Widget w ) { wid = w; }
   public virtual void draw() { wid.draw(); } 
}

class BorderDecorator : Decorator {          
   public BorderDecorator( Widget w ):base(w) {   }
   public override void draw() {
      base.draw();                           
      Console.WriteLine( "   BorderDecorator" );
}  }

class ScrollDecorator : Decorator {          
   public ScrollDecorator( Widget w ) :base(w){   }
   public override void draw() {
      base.draw();                           
      Console.WriteLine( "   ScrollDecorator" );  
}  }

public class DecoratorDemo {
   public static void Main( String[] args ) {
      Widget aWidget = new BorderDecorator(
                          new BorderDecorator(
                             new ScrollDecorator(
                                new TextField( 80, 24 ))));
      aWidget.draw();
	} 
}