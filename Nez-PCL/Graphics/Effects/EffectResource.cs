﻿using System;
using System.IO;
using Microsoft.Xna.Framework;

#if WINRT
using System.Reflection;
#endif


namespace Nez
{
	static internal class EffectResource
	{
		// sprite effects
		public static byte[] spriteBlinkEffectBytes { get { return getFileResourceBytes( "Content/nez/effects/SpriteBlinkEffect.mgfxo" ); } }
		public static byte[] crosshatchBytes { get { return getFileResourceBytes( "Content/nez/effects/Crosshatch.mgfxo" ); } }
		public static byte[] noiseBytes { get { return getFileResourceBytes( "Content/nez/effects/Noise.mgfxo" ); } }
		public static byte[] twistBytes { get { return getFileResourceBytes( "Content/nez/effects/Twist.mgfxo" ); } }
		public static byte[] dotsBytes { get { return getFileResourceBytes( "Content/nez/effects/Dots.mgfxo" ); } }

		// post processor effects
		public static byte[] bloomCombineBytes { get { return getFileResourceBytes( "Content/nez/effects/BloomCombine.mgfxo" ); } }
		public static byte[] bloomExtractBytes { get { return getFileResourceBytes( "Content/nez/effects/BloomExtract.mgfxo" ); } }
		public static byte[] gaussianBlurBytes { get { return getFileResourceBytes( "Content/nez/effects/GaussianBlur.mgfxo" ); } }
		public static byte[] vignetteBytes { get { return getFileResourceBytes( "Content/nez/effects/Vignette.mgfxo" ); } }

		public static byte[] multiTextureOverlayBytes { get { return getFileResourceBytes( "Content/nez/effects/MultiTextureOverlay.mgfxo" ); } }
		public static byte[] scanlinesBytes { get { return getFileResourceBytes( "Content/nez/effects/Scanlines.mgfxo" ); } }


		/// <summary>
		/// gets the raw byte[] from an EmbeddedResource
		/// </summary>
		/// <returns>The embedded resource bytes.</returns>
		/// <param name="name">Name.</param>
		static byte[] getEmbeddedResourceBytes( string name )
		{
			#if WINRT
			var assembly = typeof(EffectResource).GetTypeInfo().Assembly;
			#else
			var assembly = typeof( EffectResource ).Assembly;
			#endif

			using( var stream = assembly.GetManifestResourceStream( name ) )
			{
				using( var ms = new MemoryStream() )
				{
					stream.CopyTo( ms );
					return ms.ToArray();
				}
			}
		}


		/// <summary>
		/// fetches the raw byte data of a file from the Content folder. Used to keep the Effect subclass code simple and clean due to the Effect
		/// constructor requiring the byte[].
		/// </summary>
		/// <returns>The file resource bytes.</returns>
		/// <param name="path">Path.</param>
		static byte[] getFileResourceBytes( string path )
		{
			byte[] bytes;
			using( var stream = TitleContainer.OpenStream( path ) )
			{
				bytes = new byte[stream.Length];
				stream.Read( bytes, 0, bytes.Length );
			}

			return bytes;
		}
	}
}

