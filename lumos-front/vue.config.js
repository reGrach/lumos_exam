module.exports = {
    outputDir: process.env.NODE_ENV === 'production'
        ? '/var/www/lumos/site'
        : 'dist',
};