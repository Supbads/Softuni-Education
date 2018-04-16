package shapes;

public class SpecialBall extends Ball {
	public SpecialBall(double x, double y) {
		super(x, y);
	}

	@Override
	public void move(double deltaX, double deltaY) {
		throw new UnsupportedOperationException("Move not supported");
	}

	@Override
	public String toString() {
		return "SpecialBall(" + this.getX() + ", " + this.getY() + ")"; 
	}
}
