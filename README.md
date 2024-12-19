# Máquina Expendedora - Proyecto en C# 🚀

¡Bienvenido al repositorio de la Máquina Expendedora! 👋

![Icono de C#](/Images/icon-2.jpeg)

## Descripción 🔧📁
Este proyecto implementa una aplicación de máquina expendedora en C# que simula el funcionamiento de una máquina utilizada para expender productos como bebidas, chocolatinas, etc. La aplicación ofrece una interfaz de usuario intuitiva que permite a los usuarios definir parámetros de doblado y visualizar el resultado de la operación.

## Integrantes del Equipo 👥
- 💻 **Mario Martínez Lozano** - Desarrollador Software - [@marichu-kt](https://github.com/marichu-kt)

## ESTRUCTURA DEL PROGRAMA

![Estructura del programa](/Images/Estructura.png)

Esta práctica consiste en el desarrollo de una aplicación en modo consola que simule una máquina expendedora para vender diferentes tipos de productos utilizando diferentes tipos de métodos de pago.

El programa debe mostrar una interfaz de usuario básica con los diferentes productos que ofrecen las máquinas y las siguientes opciones:

- Comprar productos: esta opción permite al usuario introducir el/los ID del producto o productos que desea adquirir. Si se desean varios productos, el sistema solicitará IDs de producto hasta que el usuario decida proceder al pago. El proceso debe seguir los siguientes pasos:

    - Pedir el id de producto al usuario: se mostrarán al usuario los diferentes productos de la máquina (ID, nombre, unidades disponibles, precio), permitiendo seleccionar un producto mediante su ID. Una vez elegido, de nuevo se solicitará otro ID, o bien se le permitirá pasar al proceso de pago.
    - Preguntar por la forma de pago ofreciendo al usuario la posibilidad de elegir entre (1) pago en efectivo o (2) pago con tarjeta.
    - Si el usuario ha elegido efectivo, deberá ir introduciendo monedas de una en una hasta que el total alcance o supere el precio del producto.
    - Si el usuario ha elegido tarjeta, debe introducir los datos de la tarjeta, incluidos el número, la fecha de caducidad y el código de seguridad. Una vez pagado, la máquina dispensa el producto, actualizando las unidades disponibles.
  
  Se debe permitir al usuario cancelar la operación en cualquier momento.

- Mostrar información del producto: Esta opción permite al usuario ver la información completa sobre el producto. El proceso debe seguir los siguientes pasos:
    - Mostrar los productos disponibles (ID, nombre, unidades, precio)
    - Pedir ID del producto al usuario
    - Si el producto existe, mostrar la información del mismo (Nombre, precio, descripción, cantidad disponible, tipo de producto, y la información relevante de la categoría del producto)

- Carga individual de productos (Admin): Esta opción permite a los usuarios de tipo Administrador reponer los productos existentes o añadir nuevos productos a la máquina si el espacio lo permite. Permite: (1) añadir existencias a los productos existentes; y (2) añadir nuevos tipos de productos en las ranuras disponibles.

- Carga completa de productos (Admin): esta opción permitirá a los usuarios de tipo Administrador cargar el contenido de la máquina utilizando un archivo. 

- Salir: esta opción permitirá salir del programa.

Las opciones de administración requieren la introducción de una clave secreta para continuar. 
Esto significa que se debe pedir al usuario la clave cuando se elige esta opción y volver al menú principal si la clave no es válida.


## FLUJO DEL PROGRAMA 

El siguiente diagrama ilustra las funciones básicas del programa:

  - Función roja: función estática definida dentro del programa principal.
  - Funciones naranja: métodos públicos (funciones) pertenecientes a una clase central, idealmente llamada MaquinaVending.
  - Funciones Azules: métodos públicos que deben ser implementados en clases separadas.

![Flujo del programa](/Images/Flujo.png)

## DEFINICIÓN DE UN PRODUCTO 

La máquina expendedora está diseñada para dispensar una diversa gama de productos clasificados en tres tipos principales: (1) materiales preciosos, (2) productos alimenticios y (3) productos electrónicos. Todos los productos comparten las siguientes características comunes:

  - Nombre (string): nombre del producto.
  - Unidades (int): cantidad disponible del producto.
  - Precio unitario (double): coste por unidad del producto.
  - Descripción (string): breve descripción del producto.

Además, existen diferentes tipos de productos(materiales preciosos, productos alimenticios y productos electrónicos) que presentan características únicas:

  - Los materiales preciosos incluyen el tipo de material (por ejemplo, hierro, oro, plata, etc.) y el peso (expresado en gramos).
  - Los productos alimenticios incluyen información nutricional para informar a los consumidores sobre el recuento de calorías, el contenido de grasa, el contenido de azúcar, etc.
  - Los productos electrónicos incluyen el tipo de materiales utilizados, un indicador booleano para la inclusión de pilas (sí/no) y un indicador booleano para saber si el producto está precargado.

El usuario administrador se encarga de abastecer la máquina expendedora, ya sea de forma individual o mediante una carga de archivo. Para las actualizaciones masivas, se requiere la utilización de un archivo CSV (Comma-Separated Values) utilizando un punto y coma (;) como delimitador. El formato estructurado de este archivo incluye especificaciones detalladas para la carga de productos:

  - tipo_producto: Indica la categoría del producto, con 1 para materiales preciosos, 2 para productos alimenticios y 3 para productos electrónicos. Esta clasificación ayuda a la correcta asignación de productos dentro de la máquina expendedora.
  - nombre_producto: Identifica el producto.
  - unidades_producto: Especifica cuántas unidades del producto hay disponibles.
  - precio_unidad_producto: Enumera el precio de cada unidad.
  - descripción_del_producto: Proporciona un resumen del producto.
  - materiales: Describe los materiales que constituyen el producto, relevante a efectos de reciclaje o para artículos con requisitos específicos de composición.
  - peso: El peso del producto en gramos, significativo para materiales preciosos.
  - información_nutricional: Esencial para los artículos alimentarios, detalla aspectos nutricionales como las calorías y el contenido de azúcar.
  - tiene_bateria: Un valor booleano (1/0) que indica la inclusión de una batería.
  - precargado: Valor booleano (1/0) que indica si el producto está listo para su uso en el momento de la compra.


## CONSIDERACIONES DE DESARROLLO 

Para desarrollar el programa hay que tener en cuenta diferentes consideraciones:

La máquina tendrá 12 slots de productos  
  - Existen dos tipos de usuario: (1) cliente; y (2) admin.
  - El usuario cliente podrá ejecutar las siguientes operaciones: (1) comprar un producto; (2) mostrar productos; y (3) salir.
  - El usuario admin podrá ejecutar todas las operaciones.
  - El programa debe implementar una validación de entrada completa para manejar los errores (excepciones para la entrada del usuario).
  - No está permitido utilizar funciones como Environment.Exit(0) para finalizar el programa.
  - No está permitido utilizar break y continue en los bucles. Se deben estructurar los bucles y la lógica de forma que se evite su necesidad, promoviendo un flujo de código claro y comprensible.

## DOCUMENTACIÓN 

  - La memoria debe estar compuesta por los siguientes contenidos (se pueden incluir más contenidos en caso de que se considere oportuno):
  - Portada, seguida de un índice para facilitar la navegación por el documento.
  - Sección de Introducción debe incluir los nombres de todos los miembros del grupo y un resumen del documento.
  - La sección Descripción debe incluir una descripción detallada de la solución propuesta que abarque tanto las decisiones de diseño como de desarrollo.                                                                                  
    Es obligatorio incluir un diagrama de clases para representar visualmente todas las clases (producto, anterior, alimentación, electrónica y otras)                                                                                       
   junto con sus relaciones e interacciones. Existen diferentes herramientas para diseñar diagramas UML online. Una recomendación: drawio.comLinks to an external site.
  - La sección Problemas debe incluir los diferentes problemas o retos a los que se ha hecho frente durante el desarrollo de la solución.
  - Las sección Conclusiones debe incluir algunas conclusiones sobre el trabajo realizado, como las lecciones aprendidas, la eficacia de las soluciones desarrolladas                                                                        
    y cualquier idea obtenida que pueda servir de base para futuros proyectos.
  - El vocabulario utilizado en el documento debe ser formal, y el lenguaje utilizado debe ser el del contexto de la asignatura. El documento debe seguir                                                                                  
    la siguiente convención de nomenclatura: documento_memoria_grupo_[n] (donde n es el número de grupo).

## REGLAS

  - La práctica debe realizarse en grupos de tres alumnos.
  - El código de la práctica se alojará en un repositorio Github, donde los diferentes componentes del grupo realizarán los aportes al código. A la creación del repositorio,                                                                
    se compartirá la URL en la tarea creada a tal efecto, para que el profesor pueda realizar seguimiento del avance de la práctica.
  - Todos los componentes del grupo deben realizar sus aportes de código mediante commits al repositorio. Se considerará que un alumno no ha participado en la práctica                                                                
    grupal si se comprueba que no ha realizado aportes al código.
  - No se permiten grupos compuestos entre alumnos que repiten curso y alumnos de primer año, salvo autorización del profesor.
  - No se permiten grupos compuestos entre alumnos de diferentes grupos (A, B y C) en ningún caso.
  - Queda terminantemente prohibido el uso de sistemas de generación de código fuente como Github Copilot o ChatGPT.
  - La memoria debe tener un número máximo de 10 páginas excluyendo la portada, el resumen, el índice y la bibliografía.
  - El trabajo práctico debe entregarse en un archivo zip/rar que contenga tres carpetas distintas: (1) documentación, que contiene el archivo de la memoria en pdf;                                                                      
    (2) solución, que contiene la solución del proyecto; y (3) archivos, que contiene los archivos adicionales creados para cargar la máquina expendedora.
  - El archivo zip/rar debe nombrarse siguiendo la siguiente convención de nomenclatura: practica_grupal_grupo[n] (donde n es el número de grupo).
  - Es obligatorio utilizar los conceptos de abstracción, encapsulación, herencia y polimorfismo para el diseño de las diferentes clases, metodos y atributos.
  - La solución debe construirse utilizando .Net Framework 6.0 o superior (excluyendo .Net Core).
  - Se valorará muy positivamente el código bien estructurado y escrito de forma limpia, así como el uso de comentarios.



