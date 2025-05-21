# Métodos de Búsqueda en C&#35;

> **Repositorio académico para la materia Estructuras de Datos (2-2A)**  
> Autor: **Anton Olguin** • Mayo 2025

## 1 · Introducción
En este proyecto se implementan y comparan tres técnicas clásicas de búsqueda de datos en C&#35;:

| Método | Idea principal | Caso de uso típico |
|--------|----------------|--------------------|
| **Búsqueda Secuencial** | Recorre la colección elemento por elemento. | Listas pequeñas o sin ordenar. |
| **Búsqueda Binaria** | Divide y conquista sobre colecciones ordenadas. | Arreglos/List\<T\> previamente ordenados. |
| **Hashing (Transformación de Claves)** | Calcula un índice mediante una función hash para acceder en tiempo *O(1)* promedio. | Acceso rápido a gran cantidad de datos con claves únicas. |

El objetivo es medir su **eficiencia** y analizar **cuándo conviene** usar cada estrategia.

---

## 2 · Estructura del repositorio

MetodosBusqueda-CSharp/ ├── src/ │   ├── DataStructures/ │   │   ├── HashTable.cs   # Implementación de tabla hash con encadenamiento │   │   └── Node.cs        # Nodo genérico para la tabla │   ├── Logic/ │   │   └── Algorithms.cs  # Secuencial, Binaria y utilidades de medición │   ├── Utils/ │   │   └── StopwatchExt.cs # Extensión para medir tiempo (opcional) │   └── Program.cs         # Punto de entrada y pruebas ├── tests/                 # Scripts opcionales de benchmark ├── README.md └── LICENSE

---

## 3 · Instalación y ejecución

1. **Clonar** el repositorio  
   ```bash
   git clone https://github.com/tu-usuario/MetodosBusqueda-CSharp.git
   cd MetodosBusqueda-CSharp

2. Compilar y correr con .NET SDK 8

dotnet build -c Release
dotnet run   -c Release


3. (Opcional) Probar con datos más grandes

dotnet run -- --size 100000 --seed 42




---

4 · Explicación del código

Archivo	Puntos clave

HashTable.cs	Implementa hashing con separate chaining. Métodos Add, Remove, Contains.
Algorithms.cs	LinearSearch, BinarySearch, KeySearch (wrapper sobre HashTable). Incluye Benchmark que recibe tamaño y repeticiones.
Program.cs	Genera arreglos de enteros aleatorios, lanza los benchmarks y muestra resultados en consola.


Comentarios XML /// acompañan cada método para facilitar la generación de documentación con DocFX o VS XML Comments.


---

5 · Análisis de rendimiento

Ejecutando dotnet run -- --size 100000 --iterations 30 en una laptop i5-7300HQ @2.50 GHz, 16 GB RAM:

Método	Promedio 1 K	Promedio 10 K	Promedio 100 K

Secuencial	0.45 ms	4.2 ms	40.3 ms
Binaria	—	0.07 ms	0.31 ms
Hashing	0.02 ms	0.02 ms	0.03 ms


> Notas

Los tiempos binarios no aparecen para 1 K porque los mismos datos se reutilizan y el overhead es despreciable.

HashTable mantiene tiempo constante promedio pero puede degradar a O(n) con malas funciones hash; se usa la de .NET para claves int.




Gráficas generadas con BenchmarkDotNet se incluyen en la carpeta tests/results (no se suben al repo para mantenerlo ligero).


---

6 · Conclusiones

Secuencial es fácil de implementar y útil cuando la colección es pequeña o no está ordenada, pero escala linealmente.

Binaria ofrece una mejora drástica para colecciones ordenadas, reduciendo la complejidad a O(log n); su mayor costo es mantener el arreglo ordenado.

Hashing proporciona acceso casi constante y domina en colecciones grandes con claves dispersas, a costa de mayor uso de memoria y la necesidad de una buena función hash.


En escenarios reales, una combinación es ideal: hashing para inserciones/búsquedas frecuentes y binaria para datos mayormente estáticos que deban permanecer ordenados.


---

7 · Licencia

Este proyecto se distribuye bajo licencia MIT. Ver el archivo LICENSE para más detalles.

---

### `LICENSE` (MIT)

MIT License

Copyright (c) 2025 Anton Olguin

