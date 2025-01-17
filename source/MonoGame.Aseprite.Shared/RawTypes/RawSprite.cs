/* ----------------------------------------------------------------------------
MIT License

Copyright (c) 2018-2023 Christopher Whitley

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
---------------------------------------------------------------------------- */

namespace MonoGame.Aseprite.RawTypes;

/// <summary>
///     Defines a class that represents the raw values of a sprite.
/// </summary>
public sealed class RawSprite : IEquatable<RawSprite>
{
    private RawSlice[] _slices;

    /// <summary>
    ///     Gets the name assigned to the sprite.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Gets the raw texture that represents the source texture for the sprite.
    /// </summary>
    public RawTexture RawTexture { get; }

    /// <summary>
    ///     Gets a read-only span of the raw slice values the texture region that will be generated for the sprite.
    /// </summary>
    public ReadOnlySpan<RawSlice> Slices => _slices;

    internal RawSprite(string name, RawTexture rawTexture, RawSlice[] slices) =>
        (Name, RawTexture, _slices) = (name, rawTexture, slices);

    /// <summary>
    ///     Returns a value that indicates if the given <see cref="RawSprite"/> is equal to this
    ///     <see cref="RawSprite"/>.
    /// </summary>
    /// <param name="other">
    ///     The other <see cref="RawSprite"/> to check for equality with this <see cref="RawSprite"/>.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the given <see cref="RawSprite"/> is equal to this 
    ///     <see cref="RawSprite"/>; otherwise, <see langword="false"/>.
    /// </returns>
    public bool Equals(RawSprite? other) => other is not null
                                            && Name == other.Name
                                            && RawTexture.Equals(other.RawTexture)
                                            && Slices.SequenceEqual(other.Slices);
}
