using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pathfinding2D.SideView.BlazorGL.Application.FormElement;
using Pathfinding2D.SideView.BlazorGL.Application.Supportive.Interfaces;

namespace Pathfinding2D.SideView.BlazorGL.Application.Form;

public class ControlPanel(Point position) : IDrawableUpdateable
{
    private readonly List<IDrawableUpdateable> _formElements = [];

    public event Action<bool>? PlayButtonToggled;
    public event Action<bool>? ShowParentButtonToggled;
    public event Action<bool>? JumpingButtonToggled;
    public event Action? StepButtonClicked;
    public event Action? ResetButtonClicked;

    public void LoadContent(ContentManager cm)
    {
        var textureButtonPlay = cm.Load<Texture2D>("Textures/ButtonPlay");
        var textureButtonStop = cm.Load<Texture2D>("Textures/ButtonStop");
        var textureButtonStep = cm.Load<Texture2D>("Textures/ButtonStep");
        var textureButtonReset = cm.Load<Texture2D>("Textures/ButtonReset");
        var textureToggleShowParentOff = cm.Load<Texture2D>("Textures/ToggleShowParentOff");
        var textureToggleShowParentOn = cm.Load<Texture2D>("Textures/ToggleShowParentOn");
        var textureToggleJumpingEnabled = cm.Load<Texture2D>("Textures/ToggleJumpingOn");
        var textureToggleJumpingDisabled = cm.Load<Texture2D>("Textures/ToggleJumpingOff");

        var togglePlay = new Toggle(textureButtonPlay, textureButtonStop, position);
        var buttonStep = new Button(textureButtonStep, position + new Point(64, 0));
        var buttonReset = new Button(textureButtonReset, position + new Point(128, 0));
        var toggleShowParent = new Toggle(textureToggleShowParentOff, textureToggleShowParentOn, position + new Point(192, 0));
        var toggleJumping = new Toggle(textureToggleJumpingDisabled, textureToggleJumpingEnabled, position + new Point(256, 0));

        togglePlay.Toggled += PlayButtonToggled;
        buttonStep.Clicked += StepButtonClicked;
        buttonReset.Clicked += ResetButtonClicked;
        toggleShowParent.Toggled += ShowParentButtonToggled;
        toggleJumping.Toggled += JumpingButtonToggled;

        _formElements.Add(togglePlay);
        _formElements.Add(buttonStep);
        _formElements.Add(buttonReset);
        _formElements.Add(toggleShowParent);
        _formElements.Add(toggleJumping);
    }

    public void Update(GameTime gameTime)
    {
        foreach (var formElement in _formElements) {
            formElement.Update(gameTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var formElement in _formElements) {
            formElement.Draw(spriteBatch);
        }
    }
}