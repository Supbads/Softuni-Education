package shapes;

public class Ball implements Movable {
	private double x = 0;
	private double y = 0;

	public Ball(double x, double y) {
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

	@Override
	public String toString() {
		return "Ball(" + this.x + ", " + this.y + ")";
	}	
}
