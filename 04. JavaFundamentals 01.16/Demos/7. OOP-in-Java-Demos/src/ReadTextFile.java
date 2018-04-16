import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class ReadTextFile {
	private static String readTextFile(String fileName) throws IOException {
		StringBuilder lines = new StringBuilder();
		try (BufferedReader reader = 
				new BufferedReader(new FileReader(fileName))) {
			String newLine = System.getProperty("line.separator");
			String line;
			while ((line = reader.readLine()) != null) {
				lines.append(line);
				lines.append(newLine);
			}
		}
		return lines.toString();
	}
	
	public static void main(String[] args) {
		String fileName = "src/ReadTextFile.Java";
		try {
			String fileContent = readTextFile(fileName);
			System.out.println(fileContent);
		} catch (IOException ioex) {
			System.out.println("Can not read file: " + fileName);
		}
	}
}
