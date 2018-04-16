package com.company.Problem_2;


public abstract class Product implements Buyable {
    private String name;
    protected double price;
    private int quantity;
    private AgeRestriction ageRestrictionLevel;

    public Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super();
        this.name = name;
        this.price = price;
        this.ageRestrictionLevel = ageRestriction;
        this.quantity = quantity;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        if(name.isEmpty() || name == null){
            throw new IllegalArgumentException("Product must have a name");
        }
        this.name = name;
    }

    @Override
    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        if(price <0){
            throw new IllegalArgumentException("Product should have a price");
        }
        this.price = price;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        if(quantity<0){
            throw new IllegalArgumentException("Quantity can't be negative");
        }
        this.quantity = quantity;
    }

    public AgeRestriction getAgeRestrictionLevel() {
        return ageRestrictionLevel;
    }

    public void setAgeRestrictionLevel(AgeRestriction ageRestriction) {
        this.ageRestrictionLevel = ageRestriction;
    }

    @Override
    public String toString() {
        return "Name: " + this.name +
                "\nPrice: " + this.price +
                "\nQuantity: " + this.quantity +
                "\nAge Restriction Level: " + ageRestrictionLevel + "\n";
    }

}
