export class NumberplateLocationModel {

  // Getters and setters
  public getX() { return this.x };
  public getY() { return this.y };
  public getSeen() { return this.seen };

  public setX(value: number) { this.x = value };
  public setY(value: number) { this.y = value };
  public setSeen(value: Date) { this.seen = value; }

  private x: number;
  private y: number;
  private seen: Date;

  constructor() {
  }
}
