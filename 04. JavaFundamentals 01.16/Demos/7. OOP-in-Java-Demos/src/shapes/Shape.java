package shapes;

public abstract class Shape implements Movable, AreaCalculatable {
	protected double x = 0;
	protected double y = 0;
	
	public Shape(double x, double y) {
		this.x = x;
		this.y = y;
	}

	public double getX() {
		return x;
	}
	
	public void setX(double x) {
		this.x = x;
	}
	
	public double getY() {
		return y;
	}
	
	public void setY(double y) {
		this.y = y;
	}	

	@Override
	public void move(double deltaX, double deltaY) {
		this.x += deltaX;
		this.y += deltaY;		
	}
}
