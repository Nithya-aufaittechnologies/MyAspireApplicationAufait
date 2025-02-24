const express = require('express');
const swaggerUi = require('swagger-ui-express');
const YAML = require('yamljs');
const app = express();

// Load the Swagger YAML file
const swaggerDocument = YAML.load('./swagger.yaml');

// Serve the Swagger UI at /api-docs
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocument));

// Example API endpoint
app.get('/users', (req, res) => {
    res.json([{ id: 1, name: 'John Doe' }, { id: 2, name: 'Jane Doe' }]);
});

// Another example endpoint
app.get('/users/:id', (req, res) => {
    const user = { id: req.params.id, name: 'John Doe' };
    res.json(user);
});

// Start the server
app.listen(3000, () => {
    console.log('Server running on http://localhost:3000');
    console.log('Swagger UI is available at http://localhost:3000/api-docs');
});
