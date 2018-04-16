public class TryCatchFinally {
	public static void main(String[] args) {
		String num = "hello";
		try {
			int i = Integer.parseInt(num);
			System.out.println(i);
		} catch (NumberFormatException ex) {
			System.err.println(ex);
		} finally {
			System.out.println("This is always printed.");
		}
	}
}
