import { NumberplateLocationModel } from './NumberplateLocationsModel';

export class NumberplateModel {

  public getNumberplate() { return this.numberplate; }
  public getLocation(index: number) { return this.locations[index] };

  public setNumberplate(value: string) { this.numberplate = value; }
  private setLocations(value: NumberplateLocationModel[]) { this.locations = value; }

  private numberplate: string;
  private locations: NumberplateLocationModel[];

  constructor() {
    this.setLocations([]);
    this.setNumberplate("");
  }

  public addLocation(location: NumberplateLocationModel) {
    this.locations.push(location);
  }

  public getLatestLocation(): NumberplateLocationModel {
    let plate: NumberplateLocationModel = this.locations[0];
    for (let i = 0; i < this.locations.length; i++) {
      if (plate.getSeen() < this.locations[i].getSeen())
        plate = this.locations[i];
    }

    return plate;
  }
}
