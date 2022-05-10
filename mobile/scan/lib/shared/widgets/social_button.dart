import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class SocialLoginButton extends StatelessWidget {
  final VoidCallback onTap;
  const SocialLoginButton({Key? key, required this.onTap}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      borderOnForeground: true,
      color: Colors.white,
      elevation: 2,
      child: InkWell(
        
        onTap: onTap,
        child: SizedBox(
          
          child: Row(
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 16),
                    child: Image.asset("assets/images/logos/google.png", height: 18),
                  ),
                  const SizedBox(
                    height: 56,
                    width: 16,
                  ),
                ],
              ),
              Center(
                child: Text(
                  "ENTRAR COM O GOOGLE",
                  style: GoogleFonts.roboto(
                    color: Colors.grey.shade600,
                    fontWeight: FontWeight.bold,
                    fontSize: 18
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
