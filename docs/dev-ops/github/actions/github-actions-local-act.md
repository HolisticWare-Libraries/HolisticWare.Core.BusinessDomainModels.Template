
*   https://github.com/nektos/act

```
act -P ubuntu-latest=-self-hosted
act -P windows-latest=-self-hosted
act -P macos-latest=-self-hosted
```

```yml
  test:
    name: Test
    strategy:
      fail-fast: false
      matrix:
        net: [ '9.0', '10.0' ]
        os: [ macos-latest, windows-latest, ubuntu-latest ]
    runs-on: ${{ matrix.os }}
    needs: build
    steps:
    - name: Setup .NET
      # https://github.com/actions/setup-dotnet
      uses: actions/setup-dotnet@v5
      with:
        dotnet-version: ${{ matrix.net }}.x
    - name: Setup .NET Workloads
      run: dotnet workload install maui
    - name: Download
      # https://github.com/actions/download-artifact
      uses: actions/download-artifact@v7
      id: download
      with:
        name: nuget
        path: nuget
    - name: Setup Java
      # https://github.com/actions/setup-java
      uses: actions/setup-java@v5
      with:
        distribution: 'microsoft'
        java-version: '21'
    - name: Setup Xcode
      # https://github.com/maxim-lobanov/setup-xcode
      uses: maxim-lobanov/setup-xcode@v1
      if: ${{ matrix.os != 'windows-latest' && matrix.net == '8.0' }}
      with:
        xcode-version: 26.2
    - name: Install
      run: dotnet new install ${{steps.download.outputs.download-path}}/*.nupkg
    - name: Create
      run: dotnet new maui-multihead -o TestMauiApp -f net${{ matrix.net }}
    - name: Build Android
      run: dotnet build TestMauiApp/TestMauiApp.Droid/TestMauiApp.Droid.csproj
    - name: Build iOS
      run: dotnet build TestMauiApp/TestMauiApp.iOS/TestMauiApp.iOS.csproj
    - name: Build macOS (Mac Catalyst)
      run: dotnet build TestMauiApp/TestMauiApp.Mac/TestMauiApp.Mac.csproj
    - name: Build Windows
      if: ${{ matrix.os == 'windows-latest' }}
      run: dotnet build TestMauiApp/TestMauiApp.WinUI/TestMauiApp.WinUI.csproj -p:Platform=x64
```