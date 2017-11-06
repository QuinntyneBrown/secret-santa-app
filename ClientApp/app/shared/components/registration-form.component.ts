import {
    Component,
    Input,
    OnInit,
    EventEmitter,
    Output,
    AfterViewInit,
    AfterContentInit,
    Renderer,
    ElementRef,
} from "@angular/core";

import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
    templateUrl: "./registration-form.component.html",
    styleUrls: [
        "../../../styles/forms.css",
        "./registration-form.component.css"
    ],
    selector: "ce-registration-form"
})
export class RegistrationFormComponent {
    constructor() {
        this.register = new EventEmitter();
    }

    public form = new FormGroup({
        email: new FormControl('', [Validators.required])
    });

    @Output()
    public register: EventEmitter<any>;
}
