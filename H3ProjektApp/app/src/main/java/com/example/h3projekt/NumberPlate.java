package com.example.h3projekt;

public class NumberPlate {
    private Boolean stolen;
    private String number;
    private Double xLoc;
    private Double yLoc;


    public  NumberPlate(String _number, Double _xLoc, Double _yLoc){
        this.number = _number;
        this.xLoc = _xLoc;
        this.yLoc = _yLoc;
    }

    public Boolean getStolen() {
        return stolen;
    }

    public String getNumber() {
        return number;
    }


    public Double getxLoc() {
        return xLoc;
    }

    public Double getyLoc() {
        return yLoc;
    }
}
