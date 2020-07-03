# Empire Builder Assistant

## Overview
This is a Windows WPF app to help plan and track routes when playing the Empire Builder board game.  Features include:
* Enter card contracts and see the pick-up and drop-off locations on map, each contract has unique shape and color combination
* Control which cards and contracts are displayed on the map
* Option to show only all destination cities
* Action list to track players pickup and drop-offs, list can be re-ordered
* Draw on the map with mouse, finger or pen to track your current train tracks
     
## User guide

### Typical usage at start of game
Here is a outline of the typical way this app is used at the start of the game
1. Enter in all the contracts for the 3 cards and click 'Ok' on the edit card dialogue box
2. Use the 'Display Destination only' button to see just the destinations to easily identify destinations close to each other
3. Once you have a set of possible destinations, un-select the other contracts on the cards so only the current considered contracts are visible
4. For each contract use the dropdown box to select the best pickup location
5. Once you have your contracts and pickups selected use the 'Add' button next to each contract to add the pickup and drop-offs to the action list
6. Use the up and down buttons to arrange the optimal pickup and drop-off sequence
7. Start building to win!!!


### Entering contracts
When the app first starts you are presented with a dialogue box where you enter the three contracts from each card.  You do not have to fill in all information at once, there is a 'Edit Cards' button on the main window that will open this dialogue box up again.  If a contract is updated all that card's contracts will automatically be shown on the map.

Once a card is completed and you get a new card use the 'Edit cards' button to update the info on the new card.

In a debug build of the app a 'Randomize cards' button is visible that will quickly fill in all the contracts with random data.

### Contract icons on map
Each of the 9 contracts (3 per card) have a different color and shape combination to distinguish them on the map.  For each contract the destination city has a black outline around the shape to separate it from the pick-up locations.  Each of the three cards has a check box next to it that controls if any of the contracts from the card are visible on the map, this provides a quick way to just focus on a given card.  Within each card, each contract also has a check box that controls if that particular contract is shown on the map, if the card's check box is also checked.

If multiple pickups or drop-offs are located on the same city the colors of the icons will blend together and you can use the card and contract check box to find the overlapping contract. Overlapping pickup/drop-off are great way to maximize profit!!

There is a drop down list for each contract. The first entry for each contract is always 'Show all pickups', this option will display the destination city and all the pickup cities for that cargo. The other options for the contract correspond to one of the pickup cities for that contract.  Once a pickup city has been selected the 'Add' button can be used to add the pickup and drop-off actions to the action list.

There is a 'Display Destination only' option that hides all the pickup icons from the map. This can be useful when evaluating new contracts, especially at beginning of the game.

Another check-box labeled 'Show route icons' allows you to quickly hide all the contract icons to concentrate on the map.

### Using the action list
As mentioned above once a pickup city is selected the 'Add' button will add the pickup and drop-off actions to the action list.  The up and down arrows on the right will move the selected entry up and down the list.  The 'X' icon will delete the currently selected entry.

The clear button will clear the whole list after the user selects 'Yes' in the confirmation box.

### Drawing on the map
The map has 'wet' and 'dry' ink support, when you first draw on the map red wet ink is displayed, this can easily be erased using eraser on pen or 'Clear wet ink' button.  Once you are happy with the wet ink the 'Dry ink' button will add it to the dry green ink that cannot be erased easily.  You can use the 'Clear dry ink' option but it will erase all the dry ink.  The 'Enable wet ink' box allows you to disable wet ink so you accidentally do not draw wet ink if you touch the map.


## Posable future updates (code contributions welcome)
Here are some of the features I though about adding in the future: 
* Save/load app state, contracts, action list and ink
* Zoom feature for map
* Drag and drop support in the action list

## Version history
* 1.0 Initial release
