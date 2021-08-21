MovementBuilder

The MovementBuilder class is used as the primary developer interface for the movement system.

Initialize the MovementBuilder
AddBehaviour for each of the desired behaviours
GetDesiredMovement for final result

Initialize requires an object to be passed to implement the IMovementAgent interface.
The IMovementAgent interface requires that the implementing classes can return the current location
and future location in the form of objects that implement IMovementLocation. An IMovementLocation is
essentially a Transform without the scale. A generic MovementLocation class that implements the
IMovementLocation interface has been provided.
