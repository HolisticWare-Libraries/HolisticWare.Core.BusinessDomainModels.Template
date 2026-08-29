Fuzzer.OutOfProcess.Run
                    (
                        s =>
                        {
                            try
                            {
                                var parser = new HtmlParser();
                                parser.ParseDocument(s);
                            }
                            catch { }
                        }
                    );

