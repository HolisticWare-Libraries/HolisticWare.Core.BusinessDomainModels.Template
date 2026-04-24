# MAUI Performance Best Practices

https://learn.microsoft.com/en-us/dotnet/maui/deployment/performance?view=net-maui-10.0

https://www.telerik.com/blogs/top-5-performance-considerations-net-maui-devs

1.  Use compiled bindings

    ```xml
    <MauiEnableXamlCBindingWithSourceCompilation>true</MauiEnableXamlCBindingWithSourceCompilation>
    ```

2.  Reduce unnecessary bindings

    ```
    Button.Text = "Accept"
    ```

3.  Choose the correct layout

    bad:

     ICollection<IView>  ICollection<T>  IEnumerable<IView>  IEnumerable<T>  IList<IView>  IEnumerable

    ```xaml
    <ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
                xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                x:Class="MyMauiApp.MainPage">
        <VerticalStackLayout>
            <Image Source="waterfront.jpg" />
        </VerticalStackLayout>
    </ContentPage>
    ```


4.   Optimize image resources

5.  Reduce the number of elements on a page

6.  Reduce the application resource dictionary size

7.  Reduce the size of the app

8.  Reduce the app activation period

9.  Choose a dependency injection container carefully

10. Create Shell apps

11. Optimize ListView performance

12. Use asynchronous programming

13. Delay the cost of creating objects

14. Release IDisposable resources

15. Wrap the call to IDisposable.Dispose in a try/finally block

16. Unsubscribe from events

17. Avoid strong circular references on iOS and Mac Catalyst

1.  Avoid Deep Nesting or Improper Use of Layouts

    bad:

    ```xaml
    <VerticalStackLayout Padding="10">
        <HorizontalStackLayout Spacing="5">
            <Image
                HeightRequest="40"
                Source="dotnet_bot.png"
                WidthRequest="40" />
            <VerticalStackLayout>
                <Label Text="Full Name" />
                <Label
                    FontSize="Small"
                    Text="Role"
                    TextColor="Gray" />
            </VerticalStackLayout>
        </HorizontalStackLayout>
        <Button Text="Follow" />
    </VerticalStackLayout>
    ```

    good:

    ```xaml
    <Grid
        Padding="10"
        ColumnDefinitions="40, *"
        ColumnSpacing="10"
        RowDefinitions="20, 30, 50"
        RowSpacing="5">
        <Image Grid.RowSpan="2" Source="dotnet_bot.png" />
        <Label
            Grid.Column="1"
            FontAttributes="Bold"
            Text="Full Name" />
        <Label
            Grid.Row="1"
            Grid.Column="1"
            FontSize="Small"
            Text="Role"
            TextColor="Gray" />
        <Button
            Grid.Row="2"
            Grid.ColumnSpan="2"
            Text="Follow" />
    </Grid>    
    ```

2.  Don’t Nest Scrollable Controls Within a StackLayout

    ```xaml
    <VerticalStackLayout>
        <CollectionView...>
        </CollectionView>
    </VerticalStackLayout>
    ```

    Instead, use a Grid or AbsoluteLayout as the parent container:

    ```xaml
    <Grid>
        <CollectionView...>
        </CollectionView>
    </Grid>
    ```

3.  Skip Adding Multiple Nested Gesture Recognizers

    ```xaml
    <Grid>
        <Grid.GestureRecognizers>
        <TapGestureRecognizer Command="{Binding OuterTapCommand}" />
        </Grid.GestureRecognizers>    
        <Image...>
        <Image.GestureRecognizers>
            <TapGestureRecognizer Command="{Binding InnerTapCommand}" />
        </Image.GestureRecognizers>
        </Image>
    </Grid>
    ```

4.  Optimize Startup

5.  Efficiently Use Memory and Resources

    ```csharp
    using (var writer = File.CreateText(filePath))
    {
        await writer.WriteLineAsync("Hello from .NET MAUI!");    
    }
    ```

6.  Keep the UI Smooth

    ```csharp
    // Avoid blocking the UI thread
    var data = await LoadDataAsync();

    await Task.Run(() =>
    {
        PdfGenerator.GenerateFromExcel(excelPath, pdfPath);
    });
    ```

6.  Measure and Optimize