package com.company;
import java.io.*;
import java.util.ArrayList;

public class Problem_5_Save_an_ArrayList_of_doubles {

    public static final String FILE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem5/doubles.list";
   //public static final String SAVE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem5/my-copied-picture.jpg";

    public static void main(String[] args) throws IOException, ClassNotFoundException {
        ObjectOutputStream oos = new ObjectOutputStream( new FileOutputStream(
                FILE_PATH));
        ArrayList<Double> doubles = new ArrayList<>();
        doubles.add(5.6);
        doubles.add(45.6);
        doubles.add(3.46);
        oos.writeObject(doubles);
        oos.flush();
        oos.close();
        ObjectInputStream ois = new ObjectInputStream(
                new FileInputStream(FILE_PATH));
        System.out.println(ois.readObject());
        ois.close();
    }
}
