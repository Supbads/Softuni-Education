public class StudentExamples {
	public static void main(String[] args) {
		Student peter = new Student("Peter", 22);
		System.out.println(peter);
		System.out.println(peter.toJson());
		System.out.println("Pater's age: " + peter.getAge());
		
		System.out.println("Student icon: " + Student.getIcon());
	}
}
