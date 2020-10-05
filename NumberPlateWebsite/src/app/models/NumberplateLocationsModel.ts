
// Class to hold information about the numberplate locations
export class NumberplateLocationModel {

  // Getters and setters
  public getX() { return this.x };
  public getY() { return this.y };
  public getSeen() { return this.seen };

  public setX(value: number) { this.x = value };
  public setY(value: number) { this.y = value };
  public setSeen(value: Date) { this.seen = value; }

  // The x coordinates for the numberplates
  private x: number;

  // The y coordinates for the numberplates
  private y: number;

  // the date for when the numberplatelocation was created
  private seen: Date;

  constructor() {
  }
}
