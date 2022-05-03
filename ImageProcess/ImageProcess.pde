import shapes3d.*;
import shapes3d.contour.*;
import shapes3d.org.apache.commons.math.*;
import shapes3d.org.apache.commons.math.geometry.*;
import shapes3d.path.*;
import shapes3d.utils.*;

Ellipsoid shape;
String path = "";
float yRotation = 0;
float mouseXPosition = -1;
void settings(){
  print("------Sketch------\n");
  if(args != null){
    path = args[0];
    
    print(path + "\n");
    size(500, 500, P3D);  
  }
  else{
    print("Checkpoint 2\n");
    size(500,500, P3D);
  }
}

void setup() {
  //size(500, 500, P3D);

  shape = new Ellipsoid(
    110, 175, 110, 
    48,           
    24            
    );

  shape
    .texture(this, path)  
    .drawMode(S3D.TEXTURE);
}

void mouseDragged(){
if((mouseX > 0 ) & (mouseX < 500)){
  if(mouseXPosition < mouseX){
    mouseXPosition = mouseX;
    yRotation = yRotation + 0.05;
  }
  else{
    mouseXPosition = mouseX;
    yRotation = yRotation - 0.05;
    }
  }
}

void draw() {
  background(0);
  pushMatrix();

  translate(width/2, height/2);
  rotateY(yRotation);
  shape.draw(getGraphics());

  popMatrix();
}
