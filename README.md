# Unity 3D - Basic Gameplay Prototype

This is the working project for the Basic Gameplay portion of Unity's Programmer Pathways. It address the basic requirements as well as the bonus challenges. 

During the development of the basic gameplay, I also noticed improvements and small features that I'd like to implement at some point to improve the whole experience.

# Gameplay (MP4)

https://github.com/user-attachments/assets/c3a65e7e-f49f-418b-a910-0f8bdd34524d


## Bugs: 
- [ ] Sometimes the sandwhich projectile is triggering hits between two animals and being correctly destroyed on the second hit only
- [ ] There seems to be a bug when a collision happens between projectile and animal. Not registering very hit correctly 

## Future improvements:
- [ ] Animals should not be colliding. Introduce a slight direction change in case of animals colliding with each other. 
    - An idea is to slightly change their direction prior to the collision and return to the original direction after a few seconds.
- [ ] Implement shooting with mouse buttons
- [ ] Implement direction based shooting with mouse
- [ ] Implement better scoring system
- [ ] Improve UI indicators and trackers