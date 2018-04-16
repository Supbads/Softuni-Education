package shapes;

public class Bathroom implements AreaCalculatable {
	private double width;
	private double height;
	private double depth;

	public Bathroom(double width, double height, double depth) {
		this.width = width;
		this.height = height;
		this.depth = depth;
	}

	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}

	public double getDepth() {
		return depth;
	}

	public void setDepth(double depth) {
		this.depth = depth;
	}

	@Override
	public double calculateArea() {
		double area = 
				2 * width + height + 
				2 * width * depth + 
				2 * height * depth;
		return area;
	}

	@Override
	public String toString() {
		return "Bathroom(" + this.width + " x " + 
				this.height + " x " + this.depth + ")";
	}	
}
