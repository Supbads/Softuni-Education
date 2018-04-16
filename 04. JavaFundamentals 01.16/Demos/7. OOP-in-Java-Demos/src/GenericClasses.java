import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class GenericClasses {
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public static void main(String[] args) {
		List<String> strings = Arrays.asList("OOP", "Java", "class");
		System.out.println(strings); // [OOP, Java, class]
		
		List<Integer> nums = new ArrayList<>();
		nums.addAll(Arrays.asList(10, 20, 30));
		// nums.add("Hello"); // Compile-time error
		((List)nums).add("Hello"); // This works!
		
		System.out.println(nums); // [10, 20, 30, Hello]
		for (int num : nums) { // java.lang.ClassCastException
			System.out.println(num);
		}
	}
}
