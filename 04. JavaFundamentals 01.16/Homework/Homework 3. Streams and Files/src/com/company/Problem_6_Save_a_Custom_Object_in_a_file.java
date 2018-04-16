package com.company;


import java.io.*;

public class Problem_6_Save_a_Custom_Object_in_a_file {

    public static final String FILE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem6/waifu.save";

    public static void main(String[] args) {
        Waifu bestGrill = new Waifu("bestGrill",19,"female");
        try(
            ObjectOutputStream oos = new ObjectOutputStream(
                    new FileOutputStream(FILE_PATH));
            ObjectInputStream ois = new ObjectInputStream(
                    new FileInputStream(FILE_PATH))
        ){
            oos.writeObject(bestGrill);
            Waifu readWaifu = (Waifu)ois.readObject();
            readWaifu.introduce();

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }

    }
}
