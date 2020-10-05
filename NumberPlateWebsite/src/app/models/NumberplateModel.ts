import { NumberplateLocationModel } from './NumberplateLocationsModel';

// Class for numberplates holds information about the text of the numberplate
// And the locations for the numberplate
export class NumberplateModel {

  public getNumberplate() { return this.numberplate; }
  public getLocation(index: number) { return this.locations[index] };

  public setNumberplate(value: string) { this.numberplate = value; }
  private setLocations(value: NumberplateLocationModel[]) { this.locations = value; }

  // The numberplate in text
  private numberplate: string;

  // The locations of the numberplates
  private locations: NumberplateLocationModel[];

  constructor() {
    this.setLocations([]);
    this.setNumberplate("");
  }

  // Adds a location to the numberplate
  public addLocation(location: NumberplateLocationModel) {
    this.locations.push(location);
  }

  // Gets the latest location for the numberplate
  public getLatestLocation(): NumberplateLocationModel {
    let plate: NumberplateLocationModel = this.locations[0];
    for (let i = 0; i < this.locations.length; i++) {
      if (plate.getSeen() < this.locations[i].getSeen())
        plate = this.locations[i];
    }

    return plate;
  }
}
