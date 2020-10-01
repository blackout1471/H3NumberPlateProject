package com.example.h3projekt;

public class NumberPlate {
    private Boolean stolen;
    private String number;
    private Double xLoc;
    private Double yLoc;
    private String timeSpotted;


    public  NumberPlate(String _number, Double _xLoc, Double _yLoc, String _timeSpotted){
        this.number = _number;
        this.xLoc = _xLoc;
        this.yLoc = _yLoc;
        this.timeSpotted = _timeSpotted;
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

    public String getTimeSpotted() { return timeSpotted; }
}
