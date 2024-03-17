8. Zaimplementuj operację transpozycji macierzy Transpose(A) - zamiany wierszy na kolumny, jako metodę klasy.
9. Zaimplementuj funkcję obliczającą wyznacznik macierzy:

    - Determinant(A), jako metodę klasy
    - Det(), jako metodę instancji

10. Zaimplementuj operator jawnego rzutowania obiektu `Matrix2D` na typ tablicy regularnej `int[2,2]`
11. Zaimplementuj metodę klasy `Parse()` parsującą string do obiektu `Matrix2D`, działającą w odwrotny sposób niż `ToString()`
-- na przykład `Parse("[2, 1], [3, 2]]")` utworzy poprawnie obiekt, zaś `Parse("[[2, 1] [3, 2]]")`
zgłosi wyjątek `FormatException` - w tym przypadku brak przecinka w środku