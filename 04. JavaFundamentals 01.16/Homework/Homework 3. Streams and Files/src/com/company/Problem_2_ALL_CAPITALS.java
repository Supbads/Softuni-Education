package com.company;


import java.io.*;
import java.util.ArrayList;

public class Problem_2_ALL_CAPITALS {

    public static final String FILE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem2/lines.txt";
    public static final String SAVE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem2/output.txt";

    public static void main(String[] args) {
        try (BufferedReader reader = new BufferedReader(
                new FileReader(
                        (FILE_PATH)));
             BufferedWriter writer = new BufferedWriter(
                     new FileWriter(
                             (SAVE_PATH),true));
             PrintWriter printWriter = new PrintWriter(writer,true);
        ) {
            String line = reader.readLine();
            ArrayList<Character> output = new ArrayList<Character>();
            String strOutput;
            while(line!=null){
                strOutput="";
                for (char c : line.toCharArray()) {
                    output.add(Character.toUpperCase(c));
                }
                Character[] array = output.toArray(new Character[output.size()]);
                for (int i = 0; i < output.size(); i++) {
                    strOutput += "" + array[i];
                }

                printWriter.println(strOutput);
                output.clear();
                strOutput = "";
                line=reader.readLine();
            }

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }



    }
}
