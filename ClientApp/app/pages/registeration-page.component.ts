import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { RecipientService } from "../shared/services/recipient.service";

@Component({
    templateUrl: "./registeration-page.component.html",
    styleUrls: ["./registeration-page.component.css"],
    selector: "ce-registeration-page"
})
export class RegisterationPageComponent {
    constructor(
        protected recipientService: RecipientService,
        protected router: Router
    ) { }

    handleRegisteration($event: any) {
        this.recipientService.register({ recipient: $event.value })
            .do((x) => this.router.navigateByUrl("/"))
            .subscribe();
    }
}
