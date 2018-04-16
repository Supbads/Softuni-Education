package com.company.Problem_2.Exceptions;


public class ProductHasExpiredException extends ProductManagementException{
    public ProductHasExpiredException() {
        super("Product has expired.");
    }
}
