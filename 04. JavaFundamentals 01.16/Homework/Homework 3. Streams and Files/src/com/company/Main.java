package com.company;
import java.io.*;

public class Main {
    public static final String FILE_PATH = "C:/Users/USER/IdeaProjects/asd/src/users.txt";
    public static final String SAVE_PATH = "C:/Users/USER/IdeaProjects/asd/src/Info.txt";


    public static void main(String[] args) {
        File file = new File(FILE_PATH);

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
                String[] info = line.split(" ");
                String username = info[0];
                int totalMinutes = 0;
                for (int i = 1; i < info.length; i++) {
                    String[] loggedTime = info[i].split(":");
                    int hours = Integer.parseInt(loggedTime[0]);
                    int minutes = Integer.parseInt(loggedTime[1]);
                    totalMinutes += (hours*60) + minutes;
                }
                String output = username + " " + totalMinutes;
                //to calc the days hours and minutes
                printWriter.println(output);

            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}
