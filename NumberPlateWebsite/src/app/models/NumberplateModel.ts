export class NumberplateModel {

  LastSeen: Date;
  Location: string;

  constructor(lastseen: Date, location: string) {
    this.LastSeen = lastseen;
    this.Location = location;
  }
}
