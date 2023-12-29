This template is meant to quickstart your 3d isometric prototypes.

It includes a simple character controller (rigidbody based), with dashing, jumping and double jumping
implemented as separated components, so you can easily remove what you don't need.

Helpers.cs is a static class with useful methods accessible from everywhere within your project,
such as a ground check method, a method that rotates a given vector to fit the isometric view,
as well as a method to generate variations of your audio clips when you play them.

Unity new input system is installed thought you can use the old one instead if you want to.
Embedded input actions are implemented for keyboard and controller.