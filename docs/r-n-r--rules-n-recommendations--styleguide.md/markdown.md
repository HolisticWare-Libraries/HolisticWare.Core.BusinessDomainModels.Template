# Markdown formatting

*   style/format

    *   input/output format
    
        *    structured/semi-structured markdown

    *   inupt as markdown

        *   user will do his best to provide input as structured or semi-structured markdown

        *   after reading this document provide summary as strucutred or semi-structured markdown for verification

    *   output as markdown

        *   assistant will provide output as structured or semi-structured markdown

    *   structured or semi-strucuterd markdown

        *   not everything can be strucutred

        *   best effort to structure as much as possible
        
        *   lists represent hierarchical knowledge/mind maps

            *   numbered lists represent

                *   priority

                *   order

                *   importance of meaning

            *   unnumbered lists

                *   simple lists/enummerations

            *   sublists represent relational information (like in object oriented analysis/design/programming)

                *   inheritance

                    bad (needs more reasoning):

                    ```markdown

                    *   `Person`

                        *   `Student`

                        *   `Teacher`

                        *   `Coach`

                        *   `Athlete`
                    ```

                    good (relation is specified):

                    ```markdown

                    *   `Person` 

                        *   super-class/base-class

                            *   `Student`

                            *   `Teacher`

                            *   `Coach`

                            *   `Athlete`
                    ```

                *   aggregation

                    bad (needs more reasoning):

                    ```markdown

                    *   `Person`

                        *   `Age`

                        *   `Name`

                        *   `DateOf Birth`
                    ```

                    good (relation is specified):

                    ```markdown

                    *   `Person`

                        *   has/aggregates

                            *   `Age`

                            *   `Name`

                            *   `DateOf Birth`
                    ```

*   function/purpose

    *   clarity

    *   size (number of tokens)



format following text (markdown table) with columns that are of equal width, so it is easier to read as text too                                                                                                                              
 aligned the columns with consistent widths for better text-mode readability: 
 
```markdown
| Project | Target Frameworks | Purpose |
|---------|-------------------|---------|
| `HolisticWare.Core.BusinessDomainLogicModels` | netstandard2.0, net9.0, net10.0 | Core business domain models |
| `HolisticWare.Utilities` | netstandard2.0, net9.0, net10.0 | Shared utilities and diagnostics |
| `HolisticWare.Core.UserInterfaceUI` | net9.0, net10.0 | Base UI abstractions |
| `HolisticWare.Core.UserInterfaceUI.MAUI` | net10.0-android, ios, maccatalyst, windows | Mobile UI via MAUI |
| `HolisticWare.Core.UserInterfaceUI.Razor` | net10.0 | Blazor/Razor components |
```