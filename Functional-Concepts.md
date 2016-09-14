- partial application		
	
				f(x,y) -> x * (y + 1) 
				y = 10 => g(x) -> x * (10 + 1) 
			
- function composition ?

				f(x) -> (x + 1)^2
				k(x) -> x^2
				g(x) -> x * 1
				f(x) -> k(g(x)) -> (k >> g)(x)