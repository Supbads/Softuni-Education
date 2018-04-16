enum Day {
    SUNDAY, MONDAY, TUESDAY, WEDNESDAY,
    THURSDAY, FRIDAY, SATURDAY 
}

public class EnumsExample {

	public static void main(String[] args) {
		Day d = Day.MONDAY;
		if (d == Day.MONDAY) {
			System.out.println(d); // MONDAY
			System.out.println(d.ordinal()); // 1
		}


	}

}
