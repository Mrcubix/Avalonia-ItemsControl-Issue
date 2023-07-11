# The Issue At Hand

For some reasons, when elements are cleared and default elements are added back in another thread, avalonia will duplicate the `ContentPresenter` elements.

<p align="center">
  <img src="https://github.com/AvaloniaUI/Avalonia/assets/39861216/e67a3389-00b3-427c-895d-e786f2c33f69" alt="Avalonia bug duplicating ContentPresenter elements" />
</p>

Discussion Link: https://github.com/AvaloniaUI/Avalonia/discussions/12137