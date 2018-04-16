import java.util.Arrays;
import java.util.List;

public class StreamsOfElements {
	public static void main(String[] args) {
		List<Integer> values = Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8);
		System.out.println(values.stream()
		    .filter(e -> e > 3)
		    .filter(e -> e % 2 > 0)
		    .map(e -> e * 2)
		    .findFirst()
		);
	}
}
