
public class _101_MethodTypes {
	
	static void addOne(int n) {
		n += 1;
		System.out.println(n);
	}
	
	static int plusOne(int n) {
		return n + 1;
	}

	public static void main(String[] args) {
		
		int n = 5;
		System.out.println(n);
		addOne(n);
		System.out.println();
		System.out.println(n);
		System.out.println(plusOne(n));
		
	}
}
