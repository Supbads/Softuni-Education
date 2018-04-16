import java.util.stream.IntStream;

public class FunctionalProgramming {
	public static void main(String[] args) {
		IntStream.rangeClosed(1, 10).forEach(p -> {
			System.out.println(p + " --> " + 
					(isPrime(p) ? "prime" : "not prime"));
		});
	}
	
	private static boolean isPrime(int number) {
		return number > 1 &&
				IntStream.range(2, number).noneMatch(i -> number % i == 0);
	}
}
