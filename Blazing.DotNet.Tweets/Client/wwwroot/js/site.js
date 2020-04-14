function nudgeTwitterCard() {
    if (this.twttr && this.twttr.widgets) {
        this.twttr.widgets.load();
    }
}