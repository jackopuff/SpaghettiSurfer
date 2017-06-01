using System;
using SpaghettiSurfer.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaghettiSurfer.Model
{
	public class Projectile
	{
		// Image representing the Projectile
		private Texture2D texture;
		public Texture2D Texture
		{
			get { return texture; }
			set { texture = value; }
		}
		// Position of the Projectile relative to the upper left side of the screen
		public Vector2 position;

		// State of the Projectile
		private bool active;
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}

		// The amount of damage the projectile can inflict to an enemy
		public int damage;
		public int Damage
		{
			get { return damage; }
			set { damage = value; }
		}

		// Represents the viewable boundary of the game
		private Viewport viewport;


		// Get the width of the projectile ship
		public int Width
		{
			get { return Texture.Width; }
		}

		// Get the height of the projectile ship
		public int Height
		{
			get { return Texture.Height; }
		}

		// Determines how fast the projectile moves
		private float projectileMoveSpeed;


		public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			this.position = position;
			this.viewport = viewport;

			active = true;

			damage = 2;

			projectileMoveSpeed = 20f;
		}

		public void Update()
		{
			// Projectiles always move to the right
			position.X += projectileMoveSpeed;

			// Deactivate the bullet if it goes out of screen
			if (position.X + Texture.Width / 2 > viewport.Width)
			{
				active = false;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, position, null, Color.White, 0f, new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
		}

	}
}