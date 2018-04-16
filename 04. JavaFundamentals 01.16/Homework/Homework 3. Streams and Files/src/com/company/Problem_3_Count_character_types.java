package com.company;
import java.io.*;
import java.util.ArrayList;

public class Problem_3_Count_character_types {

    public static final String FILE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem3/words.txt";
    public static final String SAVE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem3/count-chars.txt";

    public static void main(String[] args) {
        ArrayList<Character> vowels = new ArrayList<>();
        addVowels(vowels);
        ArrayList<Character> punctuations = new ArrayList<>();
        addPunctoations(punctuations);

        int vowelCount =0;
        int punctuationsCount =0;
        int consonantsCount =0;
        try (BufferedReader reader = new BufferedReader(
                new FileReader(
                        (FILE_PATH)));
             BufferedWriter writer = new BufferedWriter(
                     new FileWriter(
                             (SAVE_PATH),true));
             PrintWriter printWriter = new PrintWriter(writer,true);
        ) {

            while (true) {
                String line = reader.readLine();
                if (line == null){
                    break;
                }
                for (Character currentChar :line.toCharArray()) {
                    if(currentChar.equals(' ')){
                        continue;
                    }
                    else if(vowels.contains(currentChar)){
                        vowelCount++;
                        continue;
                    }
                    else if(punctuations.contains(currentChar)){
                        punctuationsCount++;
                        continue;
                    }
                    else{
                        consonantsCount++;
                        continue;
                    }
                }
                // vowels -> consonants -> punctuations
                printWriter.println("Vowels: "+vowelCount);
                printWriter.println("Consonants: "+consonantsCount);
                printWriter.println("Punctuations: "+punctuationsCount);

                reader.readLine();
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }





    }

    private static void addVowels(ArrayList<Character> vowels) {
        //a, e, i, o, u
        vowels.add('a');
        vowels.add('e');
        vowels.add('i');
        vowels.add('o');
        vowels.add('u');
    }
    public static void addPunctoations(ArrayList<Character> punctuations){
        //!,.?
        punctuations.add('!');
        punctuations.add(',');
        punctuations.add('.');
        punctuations.add('?');
    }
}
