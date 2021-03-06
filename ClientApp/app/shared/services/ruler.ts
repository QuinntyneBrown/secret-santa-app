﻿import { Injectable } from "@angular/core";
import { Rectangle } from "./rectangle";

export interface IRuler {
    measure(element: HTMLElement): Promise<Rectangle>
}

@Injectable()
export class Ruler implements IRuler {
    constructor() {
        this.measure = this.measure.bind(this);
    }

    public measure(element: HTMLElement): Promise<Rectangle> {
        return new Promise((resolve) => {
            if (document.body.contains(element)) {
                const result = Rectangle.fromClientRect(element.getBoundingClientRect());
                resolve(result);
            } else {
                setTimeout(() => {
                    document.body.appendChild(element);
                    const clientRect = element.getBoundingClientRect();
                    element.parentNode.removeChild(element);
                    var result = Rectangle.fromClientRect(clientRect);
                    resolve(result);
                }, 0);
            }
        });        
    }
}