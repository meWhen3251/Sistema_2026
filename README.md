# Sistema_2026
Sistema de Gestion de Usuarios [IN-DEV]


# 🏪 Facebook Marketplace PHP — v2 Completo

Proyecto PHP educativo inspirado en la arquitectura original de Facebook (2004):
una página PHP por URL, sin frameworks, con Bootstrap 5 y seguridad moderna.

---

## 🚀 Instalación en XAMPP (3 pasos)

### 1. Copiar archivos
```
C:\xampp\htdocs\fbmarket\
```

### 2. Crear la base de datos
1. XAMPP Control Panel → Start **Apache** y **MySQL**
2. `http://localhost/phpmyadmin` → Nueva → nombre: `fb_marketplace`
3. Pestaña **Importar** → seleccionar `database.sql` → Ejecutar

### 3. Abrir
```
http://localhost/fbmarket/
```
**Demo:** `juan@ejemplo.com` / `password`

---

## 📁 Archivos del proyecto

| Archivo | Descripción |
|---|---|
| `config.php` | PDO, helpers, sesiones, CSRF, formateo |
| `index.php` | Listado principal con búsqueda y filtros |
| `buscar.php` | **Búsqueda avanzada** con `LIKE %término%` en título, descripción y vendedor |
| `articulo.php` | Detalle de artículo + carrito + consulta al vendedor |
| `publicar.php` | Crear / editar artículo con subida de imagen |
| `mis-articulos.php` | Panel del vendedor |
| `carrito.php` | **Carrito de compras** con actualización de cantidades |
| `checkout.php` | **Confirmar pedido** con datos de entrega |
| `pedido.php` | Resumen de pedido con botones para contactar vendedores |
| `mis-pedidos.php` | Historial de compras |
| `mensajes.php` | **Bandeja de conversaciones** (todas las charlas del usuario) |
| `conversacion.php` | **Hilo de mensajes** con burbujas, respuesta en tiempo real (Ctrl+Enter) |
| `perfil.php` | **Ver y editar perfil**: nombre, ciudad, teléfono, descripción, avatar, contraseña |
| `favoritos.php` | Artículos guardados |
| `vendedor.php` | Perfil público de un usuario |
| `login.php` | Inicio de sesión |
| `registro.php` | Registro de cuenta |
| `logout.php` | Cerrar sesión |
| `database.sql` | Esquema BD + datos de ejemplo |
| `includes/header.php` | Barra superior con carrito, mensajes, perfil |
| `includes/footer.php` | Cierre HTML + scripts |
| `assets/css/estilo.css` | Paleta Facebook 2004 con Bootstrap 5 |
| `assets/js/app.js` | Preview imagen, scroll chat, contador chars |

---

## 🗃️ Esquema de la base de datos

```
usuarios          → cuentas de usuario
categorias        → categorías de artículos
articulos         → publicaciones del marketplace
articulo_imagenes → galería de fotos por artículo
conversaciones    → cada par usuario+artículo tiene 1 conversación
mensajes          → mensajes dentro de una conversación
favoritos         → artículos guardados por usuario
carrito           → ítems en el carrito (por usuario)
pedidos           → órdenes confirmadas
pedido_items      → líneas de cada pedido
calificaciones    → reseñas de compradores a vendedores
```

---

## 🔒 Seguridad implementada

- **PDO + prepared statements** → sin SQL Injection
- **`htmlspecialchars()`** en toda salida → sin XSS
- **`password_hash()` / `password_verify()`** → contraseñas seguras (bcrypt)
- **Tokens CSRF** en todos los formularios POST
- **Validación de extensión y tamaño** en uploads de imágenes
- **Verificación de propiedad** antes de editar/eliminar
- **`requiereLogin()`** en todas las páginas protegidas

---

## 📚 Conceptos PHP que ilustra cada archivo

| Concepto | Dónde verlo |
|---|---|
| `LIKE %término%` con PDO | `buscar.php` líneas 30-50 |
| Modelo de conversaciones (INSERT OR SELECT) | `conversacion.php` líneas 15-35 |
| ON DUPLICATE KEY UPDATE | `carrito.php` (agregar ítem) |
| Transacción implícita multi-tabla | `checkout.php` (crear pedido + items + stock) |
| Subida de archivos con validación | `publicar.php`, `perfil.php` |
| password_hash / password_verify | `registro.php`, `perfil.php` |
| Token CSRF en formularios | `config.php` + todos los POST |
| Static PDO (conexión única) | `config.php` función `getDB()` |
| Named placeholders PDO (`:param`) | `buscar.php` |
