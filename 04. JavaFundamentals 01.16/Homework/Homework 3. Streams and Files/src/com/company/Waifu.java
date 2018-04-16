package com.company;
import java.io.Serializable;

public class Waifu implements Serializable {
    private String name;
    private String gendre;
    private int age;

    Waifu(String name_ , int age_, String gendre_){
        this.name=name_;
        this.gendre=gendre_;
        this.age=age_;
    }
    public void introduce()
    {
        System.out.println("Hi my name is " + name + " and I'm " + age + " years old "+ gendre);
    }
}
