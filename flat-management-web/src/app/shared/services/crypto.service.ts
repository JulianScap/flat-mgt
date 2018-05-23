import { Injectable } from "@angular/core";
import * as forge from "node-forge";

@Injectable()
export class CryptoService {
  private pubAsString: string =
    `-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDKkB924j+3QyeNHLCDncvFEmil
PrVJisR5QdoQLN+X2xW31gnhb+7OlOXuecK2uo2SI9mdYLvqEikX3wPXBZSt/fDl
AkZVnlG3ayMqOF0Puy05QnSGMpPObPerh0rRFtcuRl0z9NVIrmZ1yvl4e+eMpLNX
KnOHBJFwNqcSn/cZvQIDAQAB
-----END PUBLIC KEY-----
`;

  getPasswordHash(password: string): string {
    let sha256: forge.md.MessageDigest = forge.md.sha256.create();
    sha256.update(password);
    let bytes: string = sha256.digest().bytes();
    return forge.util.encode64(bytes);
  }

  encrypt(text: string): string {
    let pub = forge.pki.publicKeyFromPem(this.pubAsString);
    return pub.encrypt(text);
  }

  preparePassword(password: string): string {
    let hash: string = this.getPasswordHash(password);
    let encryptedHash = this.encrypt(hash);
    let base64EncryptedHash = forge.util.encode64(encryptedHash);

    return base64EncryptedHash;
  }
}
