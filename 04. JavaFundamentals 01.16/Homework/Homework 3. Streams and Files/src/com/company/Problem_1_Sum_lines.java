package com.company;
import java.io.*;

public class Problem_1_Sum_lines {

    public static final String FILE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem1/lines.txt";

    public static void main(String[] args) {


        try (BufferedReader reader = new BufferedReader(
                new FileReader(
                        (FILE_PATH)));
        ) {
            String line = reader.readLine();
            int sum;
            while(line!=null){
                sum=0;
                for (char c : line.toCharArray()) {
                    int value = (int)c;
                    sum +=value;
                }
                System.out.println(sum);
                line=reader.readLine();
            }


        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
